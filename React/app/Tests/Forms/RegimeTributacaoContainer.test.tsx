import React from 'react';
import { render } from '@testing-library/react';
import RegimeTributacaoIncContainer from '@/app/GerAdv_TS/RegimeTributacao/Components/RegimeTributacaoIncContainer';
// RegimeTributacaoIncContainer.test.tsx
// Mock do RegimeTributacaoInc
jest.mock('@/app/GerAdv_TS/RegimeTributacao/Crud/Inc/RegimeTributacao', () => (props: any) => (
<div data-testid='regimetributacao-inc-mock' {...props} />
));
describe('RegimeTributacaoIncContainer', () => {
  it('deve renderizar RegimeTributacaoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <RegimeTributacaoIncContainer id={id} navigator={mockNavigator} />
  );
  const regimetributacaoInc = getByTestId('regimetributacao-inc-mock');
  expect(regimetributacaoInc).toBeInTheDocument();
  expect(regimetributacaoInc.getAttribute('id')).toBe(id.toString());

});
});