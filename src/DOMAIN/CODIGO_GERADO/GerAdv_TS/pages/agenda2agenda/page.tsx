﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { Agenda2AgendaGridAdapter } from "@/app/GerAdv_TS/Agenda2Agenda/Adapter/Agenda2AgendaGridAdapter";
import Agenda2AgendaGridContainer from "@/app/GerAdv_TS/Agenda2Agenda/Components/Agenda2AgendaGridContainer";

const Agenda2AgendaPage: React.FC = () => {
    const Agenda2AgendaGrid = new Agenda2AgendaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Agenda2 Agenda" />
            <Agenda2AgendaGridContainer grid={Agenda2AgendaGrid} />
        </PageLayout>
    );
};

export default Agenda2AgendaPage;