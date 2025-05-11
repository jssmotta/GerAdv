"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { PrecatoriaGridAdapter } from "@/app/GerAdv_TS/Precatoria/Adapter/PrecatoriaGridAdapter";
import PrecatoriaGridContainer from "@/app/GerAdv_TS/Precatoria/Components/PrecatoriaGridContainer";

const PrecatoriaPage: React.FC = () => {
    const PrecatoriaGrid = new PrecatoriaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Precatoria" />
            <PrecatoriaGridContainer grid={PrecatoriaGrid} />
        </PageLayout>
    );
};

export default PrecatoriaPage;