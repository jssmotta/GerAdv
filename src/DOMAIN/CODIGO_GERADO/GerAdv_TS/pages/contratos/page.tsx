"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ContratosGridAdapter } from "@/app/GerAdv_TS/Contratos/Adapter/ContratosGridAdapter";
import ContratosGridContainer from "@/app/GerAdv_TS/Contratos/Components/ContratosGridContainer";

const ContratosPage: React.FC = () => {
    const ContratosGrid = new ContratosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Contratos" />
            <ContratosGridContainer grid={ContratosGrid} />
        </PageLayout>
    );
};

export default ContratosPage;