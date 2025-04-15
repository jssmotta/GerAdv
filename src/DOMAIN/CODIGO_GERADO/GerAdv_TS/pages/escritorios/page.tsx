"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { EscritoriosGridAdapter } from "@/app/GerAdv_TS/Escritorios/Adapter/EscritoriosGridAdapter";
import EscritoriosGridContainer from "@/app/GerAdv_TS/Escritorios/Components/EscritoriosGridContainer";

const EscritoriosPage: React.FC = () => {
    const EscritoriosGrid = new EscritoriosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Escritorios" />
            <EscritoriosGridContainer grid={EscritoriosGrid} />
        </PageLayout>
    );
};

export default EscritoriosPage;