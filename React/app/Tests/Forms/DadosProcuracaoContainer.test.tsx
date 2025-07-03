import React from 'react';
import { render } from '@testing-library/react';
import DadosProcuracaoIncContainer from '@/app/GerAdv_TS/DadosProcuracao/Components/DadosProcuracaoIncContainer';
// DadosProcuracaoIncContainer.test.tsx
// Mock do DadosProcuracaoInc
jest.mock('@/app/GerAdv_TS/DadosProcuracao/Crud/Inc/DadosProcuracao', () => (props: any) => (
<div data-testid='dadosprocuracao-inc-mock' {...props} />
));
describe('DadosProcuracaoIncContainer', () => {
  it('deve renderizar DadosProcuracaoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <DadosProcuracaoIncContainer id={id} navigator={mockNavigator} />
  );
  const dadosprocuracaoInc = getByTestId('dadosprocuracao-inc-mock');
  expect(dadosprocuracaoInc).toBeInTheDocument();
  expect(dadosprocuracaoInc.getAttribute('id')).toBe(id.toString());

});
});