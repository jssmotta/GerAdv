"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ApensoGridAdapter } from "@/app/GerAdv_TS/Apenso/Adapter/ApensoGridAdapter";
import ApensoGridContainer from "@/app/GerAdv_TS/Apenso/Components/ApensoGridContainer";

const ApensoPage: React.FC = () => {
    const ApensoGrid = new ApensoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Apenso" />
            <ApensoGridContainer grid={ApensoGrid} />
        </PageLayout>
    );
};

export default ApensoPage;