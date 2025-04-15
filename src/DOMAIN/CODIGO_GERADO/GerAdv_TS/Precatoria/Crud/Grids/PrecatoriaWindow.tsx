import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PrecatoriaInc from "../Inc/Precatoria";
import { IPrecatoria } from "../../Interfaces/interface.Precatoria";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PrecatoriaEmpty } from "@/app/GerAdv_TS/Models/Precatoria";
import { useWindow } from "@/app/hooks/useWindows";

interface PrecatoriaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPrecatoria?: IPrecatoria;
    onSuccess: () => void;
    onError: () => void;
}

const PrecatoriaWindow: React.FC<PrecatoriaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPrecatoria,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/precatoria/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPrecatoria?.id}`);
        }

    }, [isMobile, router, selectedPrecatoria]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={699}
                    newWidth={720}
                    id={(selectedPrecatoria?.id ?? 0).toString()}
                >
                    <PrecatoriaInc
                        id={selectedPrecatoria?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPrecatoria: React.FC<PrecatoriaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PrecatoriaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPrecatoria={PrecatoriaEmpty()}>
        </PrecatoriaWindow>
    )
};

export default PrecatoriaWindow;