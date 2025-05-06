"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { OperadorGrupoGridAdapter } from "@/app/GerAdv_TS/OperadorGrupo/Adapter/OperadorGrupoGridAdapter";
import OperadorGrupoGridContainer from "@/app/GerAdv_TS/OperadorGrupo/Components/OperadorGrupoGridContainer";

const OperadorGrupoPage: React.FC = () => {
    const OperadorGrupoGrid = new OperadorGrupoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Operador Grupo" />
            <OperadorGrupoGridContainer grid={OperadorGrupoGrid} />
        </PageLayout>
    );
};

export default OperadorGrupoPage;