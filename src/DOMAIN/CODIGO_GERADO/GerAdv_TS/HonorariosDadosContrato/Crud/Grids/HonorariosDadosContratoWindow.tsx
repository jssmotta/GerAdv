import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import HonorariosDadosContratoInc from "../Inc/HonorariosDadosContrato";
import { IHonorariosDadosContrato } from "../../Interfaces/interface.HonorariosDadosContrato";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { HonorariosDadosContratoEmpty } from "@/app/GerAdv_TS/Models/HonorariosDadosContrato";
import { useWindow } from "@/app/hooks/useWindows";

interface HonorariosDadosContratoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedHonorariosDadosContrato?: IHonorariosDadosContrato;
    onSuccess: () => void;
    onError: () => void;
}

const HonorariosDadosContratoWindow: React.FC<HonorariosDadosContratoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedHonorariosDadosContrato,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/honorariosdadoscontrato/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedHonorariosDadosContrato?.id}`);
        }

    }, [isMobile, router, selectedHonorariosDadosContrato]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={415}
                    newWidth={816}
                    id={(selectedHonorariosDadosContrato?.id ?? 0).toString()}
                >
                    <HonorariosDadosContratoInc
                        id={selectedHonorariosDadosContrato?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowHonorariosDadosContrato: React.FC<HonorariosDadosContratoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <HonorariosDadosContratoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedHonorariosDadosContrato={HonorariosDadosContratoEmpty()}>
        </HonorariosDadosContratoWindow>
    )
};

export default HonorariosDadosContratoWindow;