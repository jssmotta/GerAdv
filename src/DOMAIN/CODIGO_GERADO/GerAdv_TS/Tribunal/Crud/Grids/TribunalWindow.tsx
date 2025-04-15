import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TribunalInc from "../Inc/Tribunal";
import { ITribunal } from "../../Interfaces/interface.Tribunal";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TribunalEmpty } from "@/app/GerAdv_TS/Models/Tribunal";
import { useWindow } from "@/app/hooks/useWindows";

interface TribunalWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTribunal?: ITribunal;
    onSuccess: () => void;
    onError: () => void;
}

const TribunalWindow: React.FC<TribunalWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTribunal,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTribunal?.id}`);
        }

    }, [isMobile, router, selectedTribunal]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={699}
                    newWidth={720}
                    id={(selectedTribunal?.id ?? 0).toString()}
                >
                    <TribunalInc
                        id={selectedTribunal?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTribunal: React.FC<TribunalWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TribunalWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTribunal={TribunalEmpty()}>
        </TribunalWindow>
    )
};

export default TribunalWindow;