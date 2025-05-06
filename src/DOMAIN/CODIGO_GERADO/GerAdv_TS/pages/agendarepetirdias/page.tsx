"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AgendaRepetirDiasGridAdapter } from "@/app/GerAdv_TS/AgendaRepetirDias/Adapter/AgendaRepetirDiasGridAdapter";
import AgendaRepetirDiasGridContainer from "@/app/GerAdv_TS/AgendaRepetirDias/Components/AgendaRepetirDiasGridContainer";

const AgendaRepetirDiasPage: React.FC = () => {
    const AgendaRepetirDiasGrid = new AgendaRepetirDiasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Agenda Repetir Dias" />
            <AgendaRepetirDiasGridContainer grid={AgendaRepetirDiasGrid} />
        </PageLayout>
    );
};

export default AgendaRepetirDiasPage;