import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ApensoInc from "../Inc/Apenso";
import { IApenso } from "../../Interfaces/interface.Apenso";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ApensoEmpty } from "@/app/GerAdv_TS/Models/Apenso";
import { useWindow } from "@/app/hooks/useWindows";

interface ApensoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedApenso?: IApenso;
    onSuccess: () => void;
    onError: () => void;
}

const ApensoWindow: React.FC<ApensoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedApenso,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/apenso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedApenso?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedApenso]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={699}
                    newWidth={720}
                    id={(selectedApenso?.id ?? 0).toString()}
                >
                    <ApensoInc
                        id={selectedApenso?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowApenso: React.FC<ApensoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ApensoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedApenso={ApensoEmpty()}>
        </ApensoWindow>
    )
};

export default ApensoWindow;