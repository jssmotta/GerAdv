"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { LivroCaixaClientesGridAdapter } from "@/app/GerAdv_TS/LivroCaixaClientes/Adapter/LivroCaixaClientesGridAdapter";
import LivroCaixaClientesGridContainer from "@/app/GerAdv_TS/LivroCaixaClientes/Components/LivroCaixaClientesGridContainer";

const LivroCaixaClientesPage: React.FC = () => {
    const LivroCaixaClientesGrid = new LivroCaixaClientesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Livro Caixa Clientes" />
            <LivroCaixaClientesGridContainer grid={LivroCaixaClientesGrid} />
        </PageLayout>
    );
};

export default LivroCaixaClientesPage;