"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { RecadosGridAdapter } from "@/app/GerAdv_TS/Recados/Adapter/RecadosGridAdapter";
import RecadosGridContainer from "@/app/GerAdv_TS/Recados/Components/RecadosGridContainer";

const RecadosPage: React.FC = () => {
    const RecadosGrid = new RecadosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Recados" />
            <RecadosGridContainer grid={RecadosGrid} />
        </PageLayout>
    );
};

export default RecadosPage;