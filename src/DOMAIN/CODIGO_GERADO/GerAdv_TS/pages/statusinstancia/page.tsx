"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { StatusInstanciaGridAdapter } from "@/app/GerAdv_TS/StatusInstancia/Adapter/StatusInstanciaGridAdapter";
import StatusInstanciaGridContainer from "@/app/GerAdv_TS/StatusInstancia/Components/StatusInstanciaGridContainer";

const StatusInstanciaPage: React.FC = () => {
    const StatusInstanciaGrid = new StatusInstanciaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Status Instancia" />
            <StatusInstanciaGridContainer grid={StatusInstanciaGrid} />
        </PageLayout>
    );
};

export default StatusInstanciaPage;