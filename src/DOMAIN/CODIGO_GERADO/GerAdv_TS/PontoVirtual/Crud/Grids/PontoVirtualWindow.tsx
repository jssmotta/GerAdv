import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PontoVirtualInc from "../Inc/PontoVirtual";
import { IPontoVirtual } from "../../Interfaces/interface.PontoVirtual";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PontoVirtualEmpty } from "@/app/GerAdv_TS/Models/PontoVirtual";
import { useWindow } from "@/app/hooks/useWindows";

interface PontoVirtualWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPontoVirtual?: IPontoVirtual;
    onSuccess: () => void;
    onError: () => void;
}

const PontoVirtualWindow: React.FC<PontoVirtualWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPontoVirtual,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/pontovirtual/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPontoVirtual?.id}`);
        }

    }, [isMobile, router, selectedPontoVirtual]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedPontoVirtual?.id ?? 0).toString()}
                >
                    <PontoVirtualInc
                        id={selectedPontoVirtual?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPontoVirtual: React.FC<PontoVirtualWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PontoVirtualWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPontoVirtual={PontoVirtualEmpty()}>
        </PontoVirtualWindow>
    )
};

export default PontoVirtualWindow;