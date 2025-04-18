﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { NECompromissosGridAdapter } from "@/app/GerAdv_TS/NECompromissos/Adapter/NECompromissosGridAdapter";
import NECompromissosGridContainer from "@/app/GerAdv_TS/NECompromissos/Components/NECompromissosGridContainer";

const NECompromissosPage: React.FC = () => {
    const NECompromissosGrid = new NECompromissosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="N E Compromissos" />
            <NECompromissosGridContainer grid={NECompromissosGrid} />
        </PageLayout>
    );
};

export default NECompromissosPage;