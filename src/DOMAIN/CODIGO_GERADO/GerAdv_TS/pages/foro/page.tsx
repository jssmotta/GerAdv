"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ForoGridAdapter } from "@/app/GerAdv_TS/Foro/Adapter/ForoGridAdapter";
import ForoGridContainer from "@/app/GerAdv_TS/Foro/Components/ForoGridContainer";

const ForoPage: React.FC = () => {
    const ForoGrid = new ForoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Foro" />
            <ForoGridContainer grid={ForoGrid} />
        </PageLayout>
    );
};

export default ForoPage;