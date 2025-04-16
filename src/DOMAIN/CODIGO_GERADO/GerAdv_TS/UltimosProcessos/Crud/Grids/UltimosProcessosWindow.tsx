import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import UltimosProcessosInc from "../Inc/UltimosProcessos";
import { IUltimosProcessos } from "../../Interfaces/interface.UltimosProcessos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { UltimosProcessosEmpty } from "@/app/GerAdv_TS/Models/UltimosProcessos";
import { useWindow } from "@/app/hooks/useWindows";

interface UltimosProcessosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedUltimosProcessos?: IUltimosProcessos;
    onSuccess: () => void;
    onError: () => void;
}

const UltimosProcessosWindow: React.FC<UltimosProcessosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedUltimosProcessos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/ultimosprocessos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedUltimosProcessos?.id}`);
        }

    }, [isMobile, router, selectedUltimosProcessos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedUltimosProcessos?.id ?? 0).toString()}
                >
                    <UltimosProcessosInc
                        id={selectedUltimosProcessos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowUltimosProcessos: React.FC<UltimosProcessosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <UltimosProcessosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedUltimosProcessos={UltimosProcessosEmpty()}>
        </UltimosProcessosWindow>
    )
};

export default UltimosProcessosWindow;