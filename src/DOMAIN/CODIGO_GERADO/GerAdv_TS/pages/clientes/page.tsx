"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ClientesGridAdapter } from "@/app/GerAdv_TS/Clientes/Adapter/ClientesGridAdapter";
import ClientesGridContainer from "@/app/GerAdv_TS/Clientes/Components/ClientesGridContainer";

const ClientesPage: React.FC = () => {
    const ClientesGrid = new ClientesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Clientes" />
            <ClientesGridContainer grid={ClientesGrid} />
        </PageLayout>
    );
};

export default ClientesPage;