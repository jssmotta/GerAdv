"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AgendaStatusGridAdapter } from "@/app/GerAdv_TS/AgendaStatus/Adapter/AgendaStatusGridAdapter";
import AgendaStatusGridContainer from "@/app/GerAdv_TS/AgendaStatus/Components/AgendaStatusGridContainer";

const AgendaStatusPage: React.FC = () => {
    const AgendaStatusGrid = new AgendaStatusGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Agenda Status" />
            <AgendaStatusGridContainer grid={AgendaStatusGrid} />
        </PageLayout>
    );
};

export default AgendaStatusPage;