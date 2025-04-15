import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import JusticaInc from "../Inc/Justica";
import { IJustica } from "../../Interfaces/interface.Justica";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { JusticaEmpty } from "@/app/GerAdv_TS/Models/Justica";
import { useWindow } from "@/app/hooks/useWindows";

interface JusticaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedJustica?: IJustica;
    onSuccess: () => void;
    onError: () => void;
}

const JusticaWindow: React.FC<JusticaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedJustica,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/justica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedJustica?.id}`);
        }

    }, [isMobile, router, selectedJustica]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedJustica?.id ?? 0).toString()}
                >
                    <JusticaInc
                        id={selectedJustica?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowJustica: React.FC<JusticaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <JusticaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedJustica={JusticaEmpty()}>
        </JusticaWindow>
    )
};

export default JusticaWindow;