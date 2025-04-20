import React, { useState } from 'react';
import {getMemberDetails} from "../../api/api.ts";
import {MemberDetailsDto} from "../../api/types.ts";

export default function MemberDetails() {
    const [id, setId] = useState('');
    const [member, setMember] = useState<MemberDetailsDto | null>(null);

    const fetch = async (e: React.FormEvent) => {
        e.preventDefault();
            const data = await getMemberDetails(id);
            setMember(data);
    };

    return (
        <div className="bg-white p-6 rounded-xl shadow-md space-y-4">
            <h2 className="text-xl font-semibold">Member Details</h2>
            <form onSubmit={fetch} className="flex space-x-3">
                <input
                    placeholder="Member ID"
                    className="flex-1 border border-gray-300 p-3 rounded-lg focus:ring-2 focus:ring-blue-300 outline-none"
                    value={id}
                    onChange={e => setId(e.target.value)}
                />
                <button className="bg-green-500 text-white py-3 px-5 rounded-lg shadow hover:bg-green-600 transition">
                    Fetch
                </button>
            </form>
            {member && (
                <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-bold">{member.fullName}</h3>
                    <p className="text-sm text-gray-600">{member.email}</p>
                    <h4 className="mt-4 font-medium">Current Borrows:</h4>
                    <ul className="list-disc list-inside text-sm space-y-1">
                        {member.currentBorrows.map((b, i) => (
                            <li key={i}>
                                <span className="font-medium">{b.isbn}</span> —{' '}
                                <time>{new Date(b.borrowDate).toLocaleDateString()}</time>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
}
