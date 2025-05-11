"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { Apenso2GridAdapter } from "@/app/GerAdv_TS/Apenso2/Adapter/Apenso2GridAdapter";
import Apenso2GridContainer from "@/app/GerAdv_TS/Apenso2/Components/Apenso2GridContainer";

const Apenso2Page: React.FC = () => {
    const Apenso2Grid = new Apenso2GridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Apenso2" />
            <Apenso2GridContainer grid={Apenso2Grid} />
        </PageLayout>
    );
};

export default Apenso2Page;