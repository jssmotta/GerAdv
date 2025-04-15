import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import NECompromissosInc from "../Inc/NECompromissos";
import { INECompromissos } from "../../Interfaces/interface.NECompromissos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { NECompromissosEmpty } from "@/app/GerAdv_TS/Models/NECompromissos";
import { useWindow } from "@/app/hooks/useWindows";

interface NECompromissosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedNECompromissos?: INECompromissos;
    onSuccess: () => void;
    onError: () => void;
}

const NECompromissosWindow: React.FC<NECompromissosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedNECompromissos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/necompromissos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedNECompromissos?.id}`);
        }

    }, [isMobile, router, selectedNECompromissos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedNECompromissos?.id ?? 0).toString()}
                >
                    <NECompromissosInc
                        id={selectedNECompromissos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowNECompromissos: React.FC<NECompromissosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <NECompromissosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedNECompromissos={NECompromissosEmpty()}>
        </NECompromissosWindow>
    )
};

export default NECompromissosWindow;