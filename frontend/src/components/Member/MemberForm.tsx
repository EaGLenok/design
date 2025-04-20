import React, { useState } from 'react';
import {registerMember} from "../../api/api.ts";

interface MemberFormState {
    fullName: string;
    email: string;
    phoneNumber: string;
    memberId: string;
}

const fields: Array<{
    name: keyof MemberFormState;
    label: string;
    type?: React.HTMLInputTypeAttribute;
    required?: boolean;
}> = [
    { name: 'fullName', label: 'Full Name', type: 'text', required: true },
    { name: 'email', label: 'Email', type: 'email', required: true },
    { name: 'phoneNumber', label: 'Phone Number', type: 'text', required: false },
    { name: 'memberId', label: 'Member ID', type: 'text', required: true },
];

export default function MemberForm() {
    const [form, setForm] = useState<MemberFormState>({
        fullName: '',
        email: '',
        phoneNumber: '',
        memberId: ''
    });
    const [msg, setMsg] = useState<string>('');

    const submit = async (e: React.FormEvent) => {
        e.preventDefault();
            await registerMember(form);
            setMsg('Member registered 🎉');
            setForm({ fullName: '', email: '', phoneNumber: '', memberId: '' });
    };

    return (
        <form onSubmit={submit} className="space-y-6 bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-xl font-semibold">Register Member</h2>
            {msg && <div className="text-sm text-green-700 bg-green-100 p-2 rounded">{msg}</div>}
            {fields.map(({ name, label, type = 'text', required }) => (
                <div key={name} className="flex flex-col">
                    <label className="mb-1 text-sm font-medium text-gray-700">{label}</label>
                    <input
                        required={required}
                        type={type}
                        placeholder={label}
                        className="border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none"
                        value={form[name]}
                        onChange={e => setForm({ ...form, [name]: e.target.value })}
                    />
                </div>
            ))}
            <button
                type="submit"
                className="w-full bg-blue-600 text-white py-3 rounded-lg shadow hover:bg-blue-700 transition"
            >
                Register
            </button>
        </form>
    );
}
