"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AgendaQuemGridAdapter } from "@/app/GerAdv_TS/AgendaQuem/Adapter/AgendaQuemGridAdapter";
import AgendaQuemGridContainer from "@/app/GerAdv_TS/AgendaQuem/Components/AgendaQuemGridContainer";

const AgendaQuemPage: React.FC = () => {
    const AgendaQuemGrid = new AgendaQuemGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Agenda Quem" />
            <AgendaQuemGridContainer grid={AgendaQuemGrid} />
        </PageLayout>
    );
};

export default AgendaQuemPage;