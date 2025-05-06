"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { PaisesGridAdapter } from "@/app/GerAdv_TS/Paises/Adapter/PaisesGridAdapter";
import PaisesGridContainer from "@/app/GerAdv_TS/Paises/Components/PaisesGridContainer";

const PaisesPage: React.FC = () => {
    const PaisesGrid = new PaisesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Paises" />
            <PaisesGridContainer grid={PaisesGrid} />
        </PageLayout>
    );
};

export default PaisesPage;