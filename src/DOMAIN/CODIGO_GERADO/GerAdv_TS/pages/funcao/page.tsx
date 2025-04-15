"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { FuncaoGridAdapter } from "@/app/GerAdv_TS/Funcao/Adapter/FuncaoGridAdapter";
import FuncaoGridContainer from "@/app/GerAdv_TS/Funcao/Components/FuncaoGridContainer";

const FuncaoPage: React.FC = () => {
    const FuncaoGrid = new FuncaoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Função" />
            <FuncaoGridContainer grid={FuncaoGrid} />
        </PageLayout>
    );
};

export default FuncaoPage;