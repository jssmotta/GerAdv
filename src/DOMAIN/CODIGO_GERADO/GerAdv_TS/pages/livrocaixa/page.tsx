"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { LivroCaixaGridAdapter } from "@/app/GerAdv_TS/LivroCaixa/Adapter/LivroCaixaGridAdapter";
import LivroCaixaGridContainer from "@/app/GerAdv_TS/LivroCaixa/Components/LivroCaixaGridContainer";

const LivroCaixaPage: React.FC = () => {
    const LivroCaixaGrid = new LivroCaixaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Livro Caixa" />
            <LivroCaixaGridContainer grid={LivroCaixaGrid} />
        </PageLayout>
    );
};

export default LivroCaixaPage;