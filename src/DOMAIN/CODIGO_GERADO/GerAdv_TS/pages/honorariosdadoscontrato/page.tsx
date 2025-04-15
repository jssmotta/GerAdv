"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { HonorariosDadosContratoGridAdapter } from "@/app/GerAdv_TS/HonorariosDadosContrato/Adapter/HonorariosDadosContratoGridAdapter";
import HonorariosDadosContratoGridContainer from "@/app/GerAdv_TS/HonorariosDadosContrato/Components/HonorariosDadosContratoGridContainer";

const HonorariosDadosContratoPage: React.FC = () => {
    const HonorariosDadosContratoGrid = new HonorariosDadosContratoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Honorarios Dados Contrato" />
            <HonorariosDadosContratoGridContainer grid={HonorariosDadosContratoGrid} />
        </PageLayout>
    );
};

export default HonorariosDadosContratoPage;