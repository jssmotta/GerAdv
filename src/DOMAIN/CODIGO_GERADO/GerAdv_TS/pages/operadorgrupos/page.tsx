"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { OperadorGruposGridAdapter } from "@/app/GerAdv_TS/OperadorGrupos/Adapter/OperadorGruposGridAdapter";
import OperadorGruposGridContainer from "@/app/GerAdv_TS/OperadorGrupos/Components/OperadorGruposGridContainer";

const OperadorGruposPage: React.FC = () => {
    const OperadorGruposGrid = new OperadorGruposGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Operador Grupos" />
            <OperadorGruposGridContainer grid={OperadorGruposGrid} />
        </PageLayout>
    );
};

export default OperadorGruposPage;