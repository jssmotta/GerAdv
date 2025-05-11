"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { StatusAndamentoGridAdapter } from "@/app/GerAdv_TS/StatusAndamento/Adapter/StatusAndamentoGridAdapter";
import StatusAndamentoGridContainer from "@/app/GerAdv_TS/StatusAndamento/Components/StatusAndamentoGridContainer";

const StatusAndamentoPage: React.FC = () => {
    const StatusAndamentoGrid = new StatusAndamentoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Status Andamento" />
            <StatusAndamentoGridContainer grid={StatusAndamentoGrid} />
        </PageLayout>
    );
};

export default StatusAndamentoPage;