import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import Apenso2Inc from "../Inc/Apenso2";
import { IApenso2 } from "../../Interfaces/interface.Apenso2";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { Apenso2Empty } from "@/app/GerAdv_TS/Models/Apenso2";
import { useWindow } from "@/app/hooks/useWindows";

interface Apenso2WindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedApenso2?: IApenso2;
    onSuccess: () => void;
    onError: () => void;
}

const Apenso2Window: React.FC<Apenso2WindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedApenso2,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/apenso2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedApenso2?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedApenso2]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedApenso2?.id ?? 0).toString()}
                >
                    <Apenso2Inc
                        id={selectedApenso2?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowApenso2: React.FC<Apenso2WindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <Apenso2Window
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedApenso2={Apenso2Empty()}>
        </Apenso2Window>
    )
};

export default Apenso2Window;