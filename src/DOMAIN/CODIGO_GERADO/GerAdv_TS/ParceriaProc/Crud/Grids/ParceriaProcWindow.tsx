import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ParceriaProcInc from "../Inc/ParceriaProc";
import { IParceriaProc } from "../../Interfaces/interface.ParceriaProc";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ParceriaProcEmpty } from "@/app/GerAdv_TS/Models/ParceriaProc";
import { useWindow } from "@/app/hooks/useWindows";

interface ParceriaProcWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedParceriaProc?: IParceriaProc;
    onSuccess: () => void;
    onError: () => void;
}

const ParceriaProcWindow: React.FC<ParceriaProcWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedParceriaProc,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/parceriaproc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedParceriaProc?.id}`);
        }

    }, [isMobile, router, selectedParceriaProc]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedParceriaProc?.id ?? 0).toString()}
                >
                    <ParceriaProcInc
                        id={selectedParceriaProc?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowParceriaProc: React.FC<ParceriaProcWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ParceriaProcWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedParceriaProc={ParceriaProcEmpty()}>
        </ParceriaProcWindow>
    )
};

export default ParceriaProcWindow;