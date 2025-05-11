"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { StatusBiuGridAdapter } from "@/app/GerAdv_TS/StatusBiu/Adapter/StatusBiuGridAdapter";
import StatusBiuGridContainer from "@/app/GerAdv_TS/StatusBiu/Components/StatusBiuGridContainer";

const StatusBiuPage: React.FC = () => {
    const StatusBiuGrid = new StatusBiuGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Status Biu" />
            <StatusBiuGridContainer grid={StatusBiuGrid} />
        </PageLayout>
    );
};

export default StatusBiuPage;