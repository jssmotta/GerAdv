"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TribunalGridAdapter } from "@/app/GerAdv_TS/Tribunal/Adapter/TribunalGridAdapter";
import TribunalGridContainer from "@/app/GerAdv_TS/Tribunal/Components/TribunalGridContainer";

const TribunalPage: React.FC = () => {
    const TribunalGrid = new TribunalGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tribunal" />
            <TribunalGridContainer grid={TribunalGrid} />
        </PageLayout>
    );
};

export default TribunalPage;