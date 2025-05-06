import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ContratosInc from "../Inc/Contratos";
import { IContratos } from "../../Interfaces/interface.Contratos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ContratosEmpty } from "@/app/GerAdv_TS/Models/Contratos";
import { useWindow } from "@/app/hooks/useWindows";

interface ContratosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedContratos?: IContratos;
    onSuccess: () => void;
    onError: () => void;
}

const ContratosWindow: React.FC<ContratosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedContratos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/contratos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedContratos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedContratos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedContratos?.id ?? 0).toString()}
                >
                    <ContratosInc
                        id={selectedContratos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowContratos: React.FC<ContratosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ContratosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedContratos={ContratosEmpty()}>
        </ContratosWindow>
    )
};

export default ContratosWindow;