import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProValoresInc from "../Inc/ProValores";
import { IProValores } from "../../Interfaces/interface.ProValores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProValoresEmpty } from "@/app/GerAdv_TS/Models/ProValores";
import { useWindow } from "@/app/hooks/useWindows";

interface ProValoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProValores?: IProValores;
    onSuccess: () => void;
    onError: () => void;
}

const ProValoresWindow: React.FC<ProValoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProValores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/provalores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProValores?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProValores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={663}
                    newWidth={1440}
                    id={(selectedProValores?.id ?? 0).toString()}
                >
                    <ProValoresInc
                        id={selectedProValores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProValores: React.FC<ProValoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProValoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProValores={ProValoresEmpty()}>
        </ProValoresWindow>
    )
};

export default ProValoresWindow;