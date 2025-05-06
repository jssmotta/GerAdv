import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import NENotasInc from "../Inc/NENotas";
import { INENotas } from "../../Interfaces/interface.NENotas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { NENotasEmpty } from "@/app/GerAdv_TS/Models/NENotas";
import { useWindow } from "@/app/hooks/useWindows";

interface NENotasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedNENotas?: INENotas;
    onSuccess: () => void;
    onError: () => void;
}

const NENotasWindow: React.FC<NENotasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedNENotas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/nenotas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedNENotas?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedNENotas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={415}
                    newWidth={816}
                    id={(selectedNENotas?.id ?? 0).toString()}
                >
                    <NENotasInc
                        id={selectedNENotas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowNENotas: React.FC<NENotasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <NENotasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedNENotas={NENotasEmpty()}>
        </NENotasWindow>
    )
};

export default NENotasWindow;