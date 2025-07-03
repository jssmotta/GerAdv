import React from 'react';
import { render } from '@testing-library/react';
import TipoStatusBiuIncContainer from '@/app/GerAdv_TS/TipoStatusBiu/Components/TipoStatusBiuIncContainer';
// TipoStatusBiuIncContainer.test.tsx
// Mock do TipoStatusBiuInc
jest.mock('@/app/GerAdv_TS/TipoStatusBiu/Crud/Inc/TipoStatusBiu', () => (props: any) => (
<div data-testid='tipostatusbiu-inc-mock' {...props} />
));
describe('TipoStatusBiuIncContainer', () => {
  it('deve renderizar TipoStatusBiuInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TipoStatusBiuIncContainer id={id} navigator={mockNavigator} />
  );
  const tipostatusbiuInc = getByTestId('tipostatusbiu-inc-mock');
  expect(tipostatusbiuInc).toBeInTheDocument();
  expect(tipostatusbiuInc.getAttribute('id')).toBe(id.toString());

});
});