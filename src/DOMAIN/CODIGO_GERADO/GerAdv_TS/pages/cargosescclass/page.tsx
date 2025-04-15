"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { CargosEscClassGridAdapter } from "@/app/GerAdv_TS/CargosEscClass/Adapter/CargosEscClassGridAdapter";
import CargosEscClassGridContainer from "@/app/GerAdv_TS/CargosEscClass/Components/CargosEscClassGridContainer";

const CargosEscClassPage: React.FC = () => {
    const CargosEscClassGrid = new CargosEscClassGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Cargos Esc Class" />
            <CargosEscClassGridContainer grid={CargosEscClassGrid} />
        </PageLayout>
    );
};

export default CargosEscClassPage;