import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import CargosInc from "../Inc/Cargos";
import { ICargos } from "../../Interfaces/interface.Cargos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { CargosEmpty } from "@/app/GerAdv_TS/Models/Cargos";
import { useWindow } from "@/app/hooks/useWindows";

interface CargosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedCargos?: ICargos;
    onSuccess: () => void;
    onError: () => void;
}

const CargosWindow: React.FC<CargosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedCargos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/cargos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedCargos?.id}`);
        }

    }, [isMobile, router, selectedCargos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedCargos?.id ?? 0).toString()}
                >
                    <CargosInc
                        id={selectedCargos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowCargos: React.FC<CargosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <CargosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedCargos={CargosEmpty()}>
        </CargosWindow>
    )
};

export default CargosWindow;