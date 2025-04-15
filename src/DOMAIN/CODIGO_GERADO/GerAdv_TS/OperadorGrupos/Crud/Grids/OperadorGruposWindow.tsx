import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadorGruposInc from "../Inc/OperadorGrupos";
import { IOperadorGrupos } from "../../Interfaces/interface.OperadorGrupos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorGruposEmpty } from "@/app/GerAdv_TS/Models/OperadorGrupos";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorGruposWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadorGrupos?: IOperadorGrupos;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGruposWindow: React.FC<OperadorGruposWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadorGrupos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadorgrupos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadorGrupos?.id}`);
        }

    }, [isMobile, router, selectedOperadorGrupos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedOperadorGrupos?.id ?? 0).toString()}
                >
                    <OperadorGruposInc
                        id={selectedOperadorGrupos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadorGrupos: React.FC<OperadorGruposWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorGruposWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadorGrupos={OperadorGruposEmpty()}>
        </OperadorGruposWindow>
    )
};

export default OperadorGruposWindow;