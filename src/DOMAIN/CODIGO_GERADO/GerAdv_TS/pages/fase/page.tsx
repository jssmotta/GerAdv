"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { FaseGridAdapter } from "@/app/GerAdv_TS/Fase/Adapter/FaseGridAdapter";
import FaseGridContainer from "@/app/GerAdv_TS/Fase/Components/FaseGridContainer";

const FasePage: React.FC = () => {
    const FaseGrid = new FaseGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Fase" />
            <FaseGridContainer grid={FaseGrid} />
        </PageLayout>
    );
};

export default FasePage;