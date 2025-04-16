"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AndamentosMDGridAdapter } from "@/app/GerAdv_TS/AndamentosMD/Adapter/AndamentosMDGridAdapter";
import AndamentosMDGridContainer from "@/app/GerAdv_TS/AndamentosMD/Components/AndamentosMDGridContainer";

const AndamentosMDPage: React.FC = () => {
    const AndamentosMDGrid = new AndamentosMDGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Andamentos M D" />
            <AndamentosMDGridContainer grid={AndamentosMDGrid} />
        </PageLayout>
    );
};

export default AndamentosMDPage;