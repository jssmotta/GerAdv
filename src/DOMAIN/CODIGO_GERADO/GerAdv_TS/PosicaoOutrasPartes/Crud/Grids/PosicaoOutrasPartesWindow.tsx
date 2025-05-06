import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import PosicaoOutrasPartesInc from "../Inc/PosicaoOutrasPartes";
import { IPosicaoOutrasPartes } from "../../Interfaces/interface.PosicaoOutrasPartes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PosicaoOutrasPartesEmpty } from "@/app/GerAdv_TS/Models/PosicaoOutrasPartes";
import { useWindow } from "@/app/hooks/useWindows";

interface PosicaoOutrasPartesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPosicaoOutrasPartes?: IPosicaoOutrasPartes;
    onSuccess: () => void;
    onError: () => void;
}

const PosicaoOutrasPartesWindow: React.FC<PosicaoOutrasPartesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPosicaoOutrasPartes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/posicaooutraspartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPosicaoOutrasPartes?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedPosicaoOutrasPartes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedPosicaoOutrasPartes?.id ?? 0).toString()}
                >
                    <PosicaoOutrasPartesInc
                        id={selectedPosicaoOutrasPartes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPosicaoOutrasPartes: React.FC<PosicaoOutrasPartesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PosicaoOutrasPartesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPosicaoOutrasPartes={PosicaoOutrasPartesEmpty()}>
        </PosicaoOutrasPartesWindow>
    )
};

export default PosicaoOutrasPartesWindow;