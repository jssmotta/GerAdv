"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { CargosEscGridAdapter } from "@/app/GerAdv_TS/CargosEsc/Adapter/CargosEscGridAdapter";
import CargosEscGridContainer from "@/app/GerAdv_TS/CargosEsc/Components/CargosEscGridContainer";

const CargosEscPage: React.FC = () => {
    const CargosEscGrid = new CargosEscGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Cargos Esc" />
            <CargosEscGridContainer grid={CargosEscGrid} />
        </PageLayout>
    );
};

export default CargosEscPage;