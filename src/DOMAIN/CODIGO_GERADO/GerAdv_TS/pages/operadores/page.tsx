"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { OperadoresGridAdapter } from "@/app/GerAdv_TS/Operadores/Adapter/OperadoresGridAdapter";
import OperadoresGridContainer from "@/app/GerAdv_TS/Operadores/Components/OperadoresGridContainer";

const OperadoresPage: React.FC = () => {
    const OperadoresGrid = new OperadoresGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Operadores" />
            <OperadoresGridContainer grid={OperadoresGrid} />
        </PageLayout>
    );
};

export default OperadoresPage;