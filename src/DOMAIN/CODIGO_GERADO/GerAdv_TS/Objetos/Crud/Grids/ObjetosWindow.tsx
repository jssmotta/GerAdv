import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ObjetosInc from "../Inc/Objetos";
import { IObjetos } from "../../Interfaces/interface.Objetos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ObjetosEmpty } from "@/app/GerAdv_TS/Models/Objetos";
import { useWindow } from "@/app/hooks/useWindows";

interface ObjetosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedObjetos?: IObjetos;
    onSuccess: () => void;
    onError: () => void;
}

const ObjetosWindow: React.FC<ObjetosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedObjetos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/objetos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedObjetos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedObjetos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedObjetos?.id ?? 0).toString()}
                >
                    <ObjetosInc
                        id={selectedObjetos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowObjetos: React.FC<ObjetosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ObjetosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedObjetos={ObjetosEmpty()}>
        </ObjetosWindow>
    )
};

export default ObjetosWindow;