"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AgendaRecordsGridAdapter } from "@/app/GerAdv_TS/AgendaRecords/Adapter/AgendaRecordsGridAdapter";
import AgendaRecordsGridContainer from "@/app/GerAdv_TS/AgendaRecords/Components/AgendaRecordsGridContainer";

const AgendaRecordsPage: React.FC = () => {
    const AgendaRecordsGrid = new AgendaRecordsGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Agenda Records" />
            <AgendaRecordsGridContainer grid={AgendaRecordsGrid} />
        </PageLayout>
    );
};

export default AgendaRecordsPage;