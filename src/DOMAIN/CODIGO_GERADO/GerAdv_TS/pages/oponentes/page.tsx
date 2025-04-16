"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { OponentesGridAdapter } from "@/app/GerAdv_TS/Oponentes/Adapter/OponentesGridAdapter";
import OponentesGridContainer from "@/app/GerAdv_TS/Oponentes/Components/OponentesGridContainer";

const OponentesPage: React.FC = () => {
    const OponentesGrid = new OponentesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Oponentes" />
            <OponentesGridContainer grid={OponentesGrid} />
        </PageLayout>
    );
};

export default OponentesPage;