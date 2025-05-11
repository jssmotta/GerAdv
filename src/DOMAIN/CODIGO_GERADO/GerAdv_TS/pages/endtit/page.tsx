"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { EndTitGridAdapter } from "@/app/GerAdv_TS/EndTit/Adapter/EndTitGridAdapter";
import EndTitGridContainer from "@/app/GerAdv_TS/EndTit/Components/EndTitGridContainer";

const EndTitPage: React.FC = () => {
    const EndTitGrid = new EndTitGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="End Tit" />
            <EndTitGridContainer grid={EndTitGrid} />
        </PageLayout>
    );
};

export default EndTitPage;