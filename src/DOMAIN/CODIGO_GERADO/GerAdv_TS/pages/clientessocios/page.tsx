"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ClientesSociosGridAdapter } from "@/app/GerAdv_TS/ClientesSocios/Adapter/ClientesSociosGridAdapter";
import ClientesSociosGridContainer from "@/app/GerAdv_TS/ClientesSocios/Components/ClientesSociosGridContainer";

const ClientesSociosPage: React.FC = () => {
    const ClientesSociosGrid = new ClientesSociosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Clientes Socios" />
            <ClientesSociosGridContainer grid={ClientesSociosGrid} />
        </PageLayout>
    );
};

export default ClientesSociosPage;