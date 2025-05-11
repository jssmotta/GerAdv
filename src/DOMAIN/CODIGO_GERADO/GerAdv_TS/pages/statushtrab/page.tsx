"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { StatusHTrabGridAdapter } from "@/app/GerAdv_TS/StatusHTrab/Adapter/StatusHTrabGridAdapter";
import StatusHTrabGridContainer from "@/app/GerAdv_TS/StatusHTrab/Components/StatusHTrabGridContainer";

const StatusHTrabPage: React.FC = () => {
    const StatusHTrabGrid = new StatusHTrabGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Status H Trab" />
            <StatusHTrabGridContainer grid={StatusHTrabGrid} />
        </PageLayout>
    );
};

export default StatusHTrabPage;