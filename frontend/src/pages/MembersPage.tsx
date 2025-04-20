import MemberForm from "../components/Member/MemberForm.tsx";
import MemberDetails from "../components/Member/MemberDetails.tsx";


export default function MembersPage() {
    return (
        <div className="grid grid-cols-2 gap-6">
            <MemberForm />
            <MemberDetails />
        </div>
    );
}
