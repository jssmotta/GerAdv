"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AlertasGridAdapter } from "@/app/GerAdv_TS/Alertas/Adapter/AlertasGridAdapter";
import AlertasGridContainer from "@/app/GerAdv_TS/Alertas/Components/AlertasGridContainer";

const AlertasPage: React.FC = () => {
    const AlertasGrid = new AlertasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Alertas" />
            <AlertasGridContainer grid={AlertasGrid} />
        </PageLayout>
    );
};

export default AlertasPage;